using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results;

public interface IResult
{
    // Yapılan İşlem Başarılı Mı?
    bool Success { get; }

    // Yapılan İşlem Başarılı Yazısı
    string Message { get; }
}
