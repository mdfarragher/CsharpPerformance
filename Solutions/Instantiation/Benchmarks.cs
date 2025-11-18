using System;
using System.Reflection;
using System.Reflection.Emit;

using BenchmarkDotNet.Attributes;

namespace Instantiation
{
    public class Benchmarks
    {
		public delegate object ConstructorDelegate();

        public ConstructorDelegate? constructor = null;

        protected ConstructorDelegate GetConstructor(string typeName)
		{
			Type? t = Type.GetType(typeName);
			ConstructorInfo? ctor = t?.GetConstructor(new Type[0]);

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
            var obj = constructor();
		}

        [Benchmark]
		public void UseDirect()
		{
            var obj = new System.Text.StringBuilder();
		}

	}
}
