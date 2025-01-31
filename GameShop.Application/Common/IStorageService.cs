﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Application.Common
{
    public interface IStorageService
    { string GetFileUrl(string filename);
        Task SaveFileAsync(Stream mediaBinaryStream, string filename);
        Task DeleteFileAsync(string filename);

    }
}
