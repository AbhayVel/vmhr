using DummyMVC.Models;

namespace DummyMVC.Services
{
    public class LoginService
    {

        ScopedClass ScopedClass;
        SingoltoneClassExample SingoltoneClassExample;
        TransientClass TransientClass;
        public LoginService(ScopedClass ScopedClass, SingoltoneClassExample SingoltoneClassExample, TransientClass TransientClass)
        {
            this.ScopedClass = ScopedClass;
            this.SingoltoneClassExample = SingoltoneClassExample;
            this.TransientClass = TransientClass;
            this.ScopedClass.Count++;
            this.SingoltoneClassExample.Count++;
            this.TransientClass.Count++;
        }
    }
}
