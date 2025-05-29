using AP_4_LR2.Models;
using AP_4_LR2.Repositories;
using System;

namespace AP_4_LR2.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly LibraryContext _libraryContext;

        private IGenericRepository<ContentItem> _contentItemRepo;
        private IGenericRepository<Book> _bookRepo;
        private IGenericRepository<Document> _documentRepo;
        private IGenericRepository<Video> _videoRepo;
        private IGenericRepository<Audio> _audioRepo;
        private IGenericRepository<StorageLocation> _storageLocationRepo;

        public UnitOfWork(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IGenericRepository<ContentItem> ContentItemRepo =>
            _contentItemRepo ??= new GenericRepository<ContentItem>(_libraryContext);

        public IGenericRepository<Book> BookRepo =>
            _bookRepo ??= new GenericRepository<Book>(_libraryContext);

        public IGenericRepository<Document> DocumentRepo =>
            _documentRepo ??= new GenericRepository<Document>(_libraryContext);

        public IGenericRepository<Video> VideoRepo =>
            _videoRepo ??= new GenericRepository<Video>(_libraryContext);

        public IGenericRepository<Audio> AudioRepo =>
            _audioRepo ??= new GenericRepository<Audio>(_libraryContext);

        public IGenericRepository<StorageLocation> StorageLocationRepo =>
            _storageLocationRepo ??= new GenericRepository<StorageLocation>(_libraryContext);

        public void Save()
        {
            _libraryContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _libraryContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
