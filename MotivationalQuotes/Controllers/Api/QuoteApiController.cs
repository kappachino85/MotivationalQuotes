using MotivationalQuotes.Domain;
using MotivationalQuotes.Models.Requests;
using MotivationalQuotes.Models.Responses;
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

        [Route("rand"), HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _quoteService.Read());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _quoteService.ReadById(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage DeleteById(int id)
        {
            SuccessResponse response = new SuccessResponse();
            try
            {
                _quoteService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route, HttpPost]
        public HttpResponseMessage Insert(QuoteAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
            }
            try
            {
                _quoteService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateById(QuoteUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ModelState);
            }
            try
            {
                _quoteService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
