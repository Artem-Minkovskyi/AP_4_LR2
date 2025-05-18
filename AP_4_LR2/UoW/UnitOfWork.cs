using AP_4_LR2.Models;
using AP_4_LR2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_4_LR2.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;

        private readonly LibraryContext _libraryContext;
        private GenericRepository<ContentItem> _contentItemRepo;
        private GenericRepository<Book> _bookRepo;
        private GenericRepository<Document> _documentRepo;
        private GenericRepository<Video> _videoRepo;
        private GenericRepository<Audio> _audioRepo;
        private GenericRepository<StorageLocation> _storageLocationRepo;

        public UnitOfWork(LibraryContext context)
        {
            _libraryContext = context;
        }

        public GenericRepository<ContentItem> ContentItemRepo =>
            _contentItemRepo ??= new GenericRepository<ContentItem>(_libraryContext);

        public GenericRepository<Book> BookRepo =>
            _bookRepo ??= new GenericRepository<Book>(_libraryContext);

        public GenericRepository<Document> DocumentRepo =>
            _documentRepo ??= new GenericRepository<Document>(_libraryContext);

        public GenericRepository<Video> VideoRepo =>
            _videoRepo ??= new GenericRepository<Video>(_libraryContext);

        public GenericRepository<Audio> AudioRepo =>
            _audioRepo ??= new GenericRepository<Audio>(_libraryContext);

        public GenericRepository<StorageLocation> StorageLocationRepo =>
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
