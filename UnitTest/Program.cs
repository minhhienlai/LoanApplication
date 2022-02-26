using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWorkTest();
            unitOfWork.InitUnitOfWork();
            unitOfWork.RunWorks();
        }
    }
}