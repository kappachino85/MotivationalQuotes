using DbConnector.Adapter;
using MotivationalQuotes.Domain;
using MotivationalQuotes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MotivationalQuotes.Services
{
    public class QuoteService : IQuoteService
    {
        IBaseService _baseService;

        public QuoteService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public IEnumerable<Quotes> ReadAll()
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public IEnumerable<Quotes> Read()
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_Select",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public Quotes ReadById(int id)
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_SelectById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            }).FirstOrDefault();
        }

    }
}