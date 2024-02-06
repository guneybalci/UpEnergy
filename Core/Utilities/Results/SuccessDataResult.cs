using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public class SuccessDataResult<T> : DataResult<T>
{
    // İşlem Başaralı Olduğunda Data , Success ve Message Geçilebilir
    public SuccessDataResult(T data, bool success, string message) : base(data, true, message)
    {
    }

    // İşlem Başaralı Olduğunda Sadece Data Geçilebilir
    public SuccessDataResult(T data) : base(data, true)
    {
    }

    // İşlem Başaralı Olduğunda Sadece Mesaj Geçilebilir
    public SuccessDataResult(string message) : base(default, true, message)
    {
    }

    public SuccessDataResult():base(default,true)
    {
        
    }
}
