using DbConnector.Adapter;
using DbConnector.Tools;
using MotivationalQuotes.Domain;
using MotivationalQuotes.Models.Requests;
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

        //this will be used to DISPLAY ALL the quotes for users to edit
        public IEnumerable<Quotes> ReadAll()
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        //this is to GET A RANDOM QUOTE from the database to display on the main page
        public IEnumerable<Quotes> Read()
        {
            return _baseService.SqlAdapter.LoadObject<Quotes>(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_Select",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        //when users SELECT A QUOTE on the edit page, this will call that procedure
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

        public int Insert(QuoteAddRequest model)
        {
            SqlParameter id = SqlDbParameter.Instance.BuildParam("@Id", 0, System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output);
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_Insert",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Quote", model.Quote),
                    new SqlParameter("@Author", model.Author),
                    id
                }       
            });
            return id.Value.ToInt32();
        }

        public void Delete(int id)
        {
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_Delete",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            });
        }

        public void Update(QuoteUpdateRequest model)
        {
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.Quotes_Update",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@Quote", model.Quote),
                    new SqlParameter("@Author", model.Author)
                }
            });
        }
    }
}