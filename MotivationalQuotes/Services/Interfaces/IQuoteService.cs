using MotivationalQuotes.Domain;
using MotivationalQuotes.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotivationalQuotes.Services.Interfaces
{
    public interface IQuoteService
    {
        IEnumerable<Quotes> ReadAll();
        IEnumerable<Quotes> Read();
        Quotes ReadById(int Id);
        int Insert(QuoteAddRequest model);
        void Delete(int id);
        void Update(QuoteUpdateRequest model);
    }
}
