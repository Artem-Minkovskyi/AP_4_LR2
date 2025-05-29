using AP_4_LR2.Models;
using AP_4_LR2.Repositories;
using System;

namespace AP_4_LR2.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ContentItem> ContentItemRepo { get; }
        IGenericRepository<Book> BookRepo { get; }
        IGenericRepository<Document> DocumentRepo { get; }
        IGenericRepository<Video> VideoRepo { get; }
        IGenericRepository<Audio> AudioRepo { get; }
        IGenericRepository<StorageLocation> StorageLocationRepo { get; }

        void Save();
    }
}
