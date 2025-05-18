using AP_4_LR2.Models;
using AP_4_LR2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_4_LR2.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<ContentItem> ContentItemRepo { get; }
        GenericRepository<Book> BookRepo { get; }
        GenericRepository<Document> DocumentRepo { get; }
        GenericRepository<Video> VideoRepo { get; }
        GenericRepository<Audio> AudioRepo { get; }
        GenericRepository<StorageLocation> StorageLocationRepo { get; }

        void Save();
    }
}
