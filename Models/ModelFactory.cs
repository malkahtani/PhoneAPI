
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace PhoneAPI.Models
{
    public class ModelFactory
    {
         
        private UrlHelper _UrlHelper;
        private IDepRepository _drepo;
        private IRankRepository _rrepo;
        private IEmpRepository _erepo;
        public ModelFactory(HttpRequestMessage request, IDepRepository repo)
        {
            _UrlHelper = new UrlHelper(request);
            _drepo = repo;
        }
        public ModelFactory(HttpRequestMessage request, IEmpRepository repo)
        {
            _UrlHelper = new UrlHelper(request);
            _erepo = repo;
        }
        public ModelFactory(HttpRequestMessage request, IRankRepository repo)
        {
            _UrlHelper = new UrlHelper(request);
            _rrepo = repo;
        }
        

        public DepModel Create(Dep dep)
        {
            return new DepModel()
            {
                dep_Id = dep.dep_Id,
                dep_name = dep.dep_name
                
            };
        }

        public RankModel Create(Rank rank)
        {
            return new RankModel()
            {
                
                rank_Id = rank.rank_Id,
                rank_name = rank.rank_name
                
            };
        }

        public EmpModel Create(Emp emp)
        {
            return new EmpModel()
            {
                emp_Id = emp.emp_Id,
                emp_name = emp.emp_name,
                mobile = emp.mobile,
                phone = emp.phone,
                dep_Id = emp.dep_Id,
                rank_Id = emp.rank_Id
            };
        }

        public Dep Parse(DepModel model)
        {
            try
            {
                var dep = new Dep()
                {
                    dep_Id = model.dep_Id,
                    dep_name = model.dep_name
                    
                };

                return dep;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Rank Parse(RankModel model)
        {
            try
            {
                var rank = new Rank()
                {
                    rank_Id = model.rank_Id,
                    rank_name = model.rank_name

                };

                return rank;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Emp Parse(EmpModel model)
        {
            try
            {
                var emp = new Emp()
                {
                    emp_Id = model.emp_Id,
                    emp_name = model.emp_name,
                    mobile = model.mobile,
                    phone = model.phone,
                    dep_Id = model.dep_Id,
                    rank_Id = model.rank_Id

                };

                return emp;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}