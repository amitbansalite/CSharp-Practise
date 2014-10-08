using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.DesignPatterns
{
    // Method 1 : in case of sealed classes that does not use unmanaged resources

    public sealed class DisposePattern : IDisposable
    {
        public void Dispose()
        {
            // get rid of managed resources, call Dispose on member variables
        }
    }



    // Method 2 : in case of an unsealed class, do it like this :
    
    public class B : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);              //I am calling you from Dispose, it's safe
            GC.SuppressFinalize(this);  //Hey, GC: don't bother calling finalize later
        }

        protected virtual void Dispose(bool itIsSafeToAlsoFreeManagedObjects)
        {
            if (itIsSafeToAlsoFreeManagedObjects)
            {
                // get rid of managed resources
            }
            // get rid of unmanaged resources
        }

        // only if you use unmanaged resources directly in this class
        //~B()
        //{
        //    Dispose(false);
        //}
    }

    public class C : B
    {
        private IntPtr m_Handle;    // unmanaged resource

        protected override void Dispose(bool itIsSafeToAlsoFreeManagedObjects)
        {
            if (itIsSafeToAlsoFreeManagedObjects)
            {
                // get rid of managed resources
            }
            //ReleaseHandle(m_Handle);

            base.Dispose(itIsSafeToAlsoFreeManagedObjects);
        }

        // again the finalizer should only be implemented if using unmanaged resources
        ~C()
        {
            Dispose(false);
        }
    }
}
