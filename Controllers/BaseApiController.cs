using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneAPI.Models;

namespace PhoneAPI.Controllers
{
            public class BaseApiController : ApiController
        {
            private IDepRepository _drepo;
            private IRankRepository _rrepo;
            private IEmpRepository _erepo;
            private ModelFactory _modelFactory;

            public BaseApiController(IDepRepository repo)
            {
                _drepo = repo;
            }
            public BaseApiController(IEmpRepository repo)
            {
                _erepo = repo;
            }
            public BaseApiController(IRankRepository repo)
            {
                _rrepo = repo;
            }

            protected ModelFactory TheDepModelFactory
            {
                get
                {
                    if (_modelFactory == null)
                    {
                        _modelFactory = new ModelFactory(Request, TheDepRepository);
                    }
                    return _modelFactory;
                }
            }

            protected IDepRepository TheDepRepository
            {
                get
                {
                    return _drepo;
                }
            }
                protected ModelFactory TheEmpModelFactory
            {
                get
                {
                    if (_modelFactory == null)
                    {
                        _modelFactory = new ModelFactory(Request, TheEmpRepository);
                    }
                    return _modelFactory;
                }
            }
                protected IEmpRepository TheEmpRepository
            {
                get
                {
                    return _erepo;
                }
            }
                protected ModelFactory TheRankModelFactory
            {
                get
                {
                    if (_modelFactory == null)
                    {
                        _modelFactory = new ModelFactory(Request, TheRankRepository);
                    }
                    return _modelFactory;
                }
            }
                protected IRankRepository TheRankRepository
            {
                get
                {
                    return _rrepo;
                }
            }
        }
    }
