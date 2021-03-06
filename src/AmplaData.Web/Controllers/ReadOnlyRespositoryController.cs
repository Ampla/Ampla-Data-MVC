﻿using System.Web.Mvc;

using AmplaData.Records;

namespace AmplaData.Web.Controllers
{
    [Authorize]
    public abstract class ReadOnlyRepositoryController<TModel> : BootstrapBaseController, IReadOnlyRepositoryController<TModel> where TModel : class, new()
    {
        protected ReadOnlyRepositoryController(IReadOnlyRepository<TModel> repository)
        {
            Repository = repository;
        }

        protected IReadOnlyRepository<TModel> Repository { get; private set; }

        /// <summary>
        ///     GET /{Model}/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("Index", Repository.GetAll());
        }

        /// <summary>
        ///     GET /{Model}/Details/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id = 0)
        {
            TModel model = Repository.FindById(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Details", model);
        }

        /// <summary>
        ///     GET /{Model}/Record/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Record(int id = 0)
        {
            AmplaRecord model = Repository.FindRecord(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Record", model);
        }
    }
}