using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Examples
{
    class Dummy : IDisposable
    {
        Stream stream;//<-instance 
        public void Dispose()
        {
            stream.Close();
            stream.Dispose();
             //Unmanaged code 
           //  try to close this in side dispose.
        }
    }
}
