using MotivationalQuotes.Domain;
using MotivationalQuotes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MotivationalQuotes.Controllers.Api
{
    [RoutePrefix("api/quotes")]
    public class QuoteApiController : ApiController
    {
        IQuoteService _quoteService;

        public QuoteApiController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _quoteService.ReadAll());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
