using System;
using System.Reflection;
using System.Reflection.Emit;

using BenchmarkDotNet.Attributes;

namespace Instantiation
{
    [CsvMeasurementsExporter]
    [RPlotExporter]
    public class Benchmarks
    {
		public delegate object ConstructorDelegate();

        public ConstructorDelegate? constructor = null;

        protected ConstructorDelegate GetConstructor(string typeName)
		{
			Type? t = Type.GetType(typeName);
            if (t == null)
                throw new NullReferenceException("t cannot be null");
			ConstructorInfo? ctor = t?.GetConstructor(new Type[0]);
            if (ctor == null)
                throw new NullReferenceException("Ctor cannot be null");

			// create a new dynamic method that constructs and returns the type
			string methodName = t.Name + "Ctor";
			DynamicMethod dm = new DynamicMethod(methodName, t, new Type[0], typeof(Activator));
			ILGenerator lgen = dm.GetILGenerator();
			lgen.Emit(OpCodes.Newobj, ctor);
			lgen.Emit(OpCodes.Ret);

			// add delegate to dictionary and return
			ConstructorDelegate creator = (ConstructorDelegate)dm.CreateDelegate(typeof(ConstructorDelegate));

			// return a delegate to the method
			return creator;
		}

        [GlobalSetup]
        public void Setup()
        {
            constructor = GetConstructor("System.Text.StringBuilder");
        }

        [Benchmark]
		public void UseActivator()
		{
			Type type = typeof(System.Text.StringBuilder);
            var obj = Activator.CreateInstance(type);
		}

        [Benchmark]
		public void UseDynamicMethod()
		{
            if (constructor == null)
                throw new NullReferenceException("Constructor may not be null");
            var obj = constructor();
		}

        [Benchmark]
		public void UseDirect()
		{
            var obj = new System.Text.StringBuilder();
		}

	}
}
