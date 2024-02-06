using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public class ErrorDataResult<T>:DataResult<T>
{
    // İşlem Başarısız Olduğunda Data , Success ve Message Geçilebilir
    public ErrorDataResult(T data, bool success, string message) : base(data, false, message)
    {
    }

    // İşlem Başarısız Olduğunda Sadece Data Geçilebilir
    public ErrorDataResult(T data) : base(data, false)
    {
    }

    // İşlem Başarısız Olduğunda Sadece Mesaj Geçilebilir
    public ErrorDataResult(string message) : base(default, false, message)
    {
    }

    public ErrorDataResult() : base(default, false)
    {

    }
}
