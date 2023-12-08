using System;
using System.Reflection;
using System.Reflection.Emit;

using BenchmarkDotNet.Attributes;

namespace Instantiation
{
    [CsvExporter]
    public class Benchmarks
    {
		// ==============================================================================
		// Benchmarks
		//
		// Complete this benchmark class so that you can measure the performance of:
		//   - Constucting an object by calling the constructor directly
		//   - Contructing an object by using Activator.CreateInstance
		//   - Constructing an object by using a dynamic method
		//
		// Which is the fastest in C#?
		// ==============================================================================

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
		public void UseDirect()
		{
            var obj = new System.Text.StringBuilder();
		}

        [Benchmark]
		public void UseActivator()
		{
			// Put code here that instantiates a StringBuilder by using Activator.CreateInstance
		}

        [Benchmark]
		public void UseDynamicMethod()
		{
			// Put code here that instantiates a StringBuilder by calling the dynamic method delegate
		}


	}
}
