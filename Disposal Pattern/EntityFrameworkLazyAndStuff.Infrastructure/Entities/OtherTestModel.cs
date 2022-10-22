using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace EntityFrameworkLazyAndStuff.Infrastructure.Entities
{
    public class OtherTestModel : IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaTetModelId { get; set; }
        public virtual MaTestModel MaTest { get; set; }
        
        private bool _disposed;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _safeHandle.Dispose();
            }

            _disposed = true;
        }
    }
}
