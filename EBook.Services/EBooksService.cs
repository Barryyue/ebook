﻿namespace EBook.Services
{
    using EBook.Domain;
    using EBook.Persistence.Contracts;
    using EBook.Services.Contracts;
    using EBook.Services.Queries;
    using EBook.Services.Queries.Fuzzy;
    using EBook.Services.Queries.Match;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EBooksService : IEBooksService
    {
        private readonly IEBooksRepository _eBooksRepository;

        public EBooksService(IEBooksRepository eBooksRepository)
            => _eBooksRepository = eBooksRepository;

        public async Task<IEnumerable<Book>> SearchByAuthor(string author)
        {
            var searchByAuthorQuery = new EBookAuthorQuery(author);
            return await Search(searchByAuthorQuery);
        }

        public async Task<IEnumerable<Book>> SearchByCategory(string category)
        {
            var searchByCategoryQuery = new EBookCategoryQuery(category);
            return await Search(searchByCategoryQuery);
        }

        public async Task<IEnumerable<Book>> SearchByKeywords(string keywords)
        {
            var searchByKeywordsQuery = new EBookKeywordsQuery(keywords);
            return await Search(searchByKeywordsQuery);
        }

        public async Task<IEnumerable<Book>> SearchByLanguage(string language)
        {
            var searchByLanguageQuery = new EBookLanguageQuery(language);
            return await Search(searchByLanguageQuery);
        }

        public async Task<IEnumerable<Book>> SearchByTitle(string title)
        {
            var searchByTitleQuery = new EBookTitleQuery(title);
            return await Search(searchByTitleQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByAuthor(string author)
        {
            var searchByAuthorFuzzyQuery = new EBookAuthorFuzzyQuery(author);
            return await Search(searchByAuthorFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByCategory(string category)
        {
            var searchByCategoryFuzzyQuery = new EBookCategoryFuzzyQuery(category);
            return await Search(searchByCategoryFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByKeywords(string keywords)
        {
            var searchByKeywordsFuzzyQuery = new EBookKeywordsFuzzyQuery(keywords);
            return await Search(searchByKeywordsFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByLanguage(string language)
        {
            var searchByLanguageFuzzyQuery = new EBookLanguageFuzzyQuery(language);
            return await Search(searchByLanguageFuzzyQuery);
        }

        public async Task<IEnumerable<Book>> FuzzySearchByTitle(string title)
        {
            var searchByTitleFuzzyQuery = new EBookTitleFuzzyQuery(title);
            return await Search(searchByTitleFuzzyQuery);
        }        

        private async Task<IEnumerable<Book>> Search(SearchRequestSpecification<Book> query)
        {
            try
            {
                var eBooks = await _eBooksRepository.Search(query.IsSatisfiedBy());
                return eBooks;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
