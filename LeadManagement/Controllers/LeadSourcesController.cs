using Domain.Abstract.Entity.Logic;
using Domain.Entity;
using LeadManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.Controllers
{
    [Authorize]
    public class LeadSourcesController : Controller
    {
        ILeadSourceLogic _leadSourceLogic;

        public LeadSourcesController(ILeadSourceLogic leadSourceLogic)
        {
            _leadSourceLogic = leadSourceLogic;
        }
        // GET: LeadSourcesController
        public ActionResult Index()
        {
            var leadSources = _leadSourceLogic.GetLeadSources();
            return View(leadSources);
        }

        // GET: LeadSourcesController/Details/5
        public ActionResult Details(int id)
        {
            var leadSources = _leadSourceLogic.GetLeadSourceById(id);
            return View(leadSources);
        }

        // GET: LeadSourcesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadSourcesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeadSourceVM leadSourceVM)
        {
            if (ModelState.IsValid)
            {
                var leadSource = new LeadSource
                {
                    Source = leadSourceVM.Source,

                    Description = leadSourceVM.Description
                };
                _leadSourceLogic.InsertLeadSource(leadSource);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: LeadSourcesController/Edit/5
        public ActionResult Edit(int id)
        {
            var lead=_leadSourceLogic.GetLeadSourceById(id);
            return View(lead);
        }

        // POST: LeadSourcesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeadSource leadSource)
        {
            //var leadSource = new LeadSource
            //{
            //    Source = leadSourceVM.Source,

            //    Description = leadSourceVM.Description
            //};
            _leadSourceLogic.UpdateLeadSource(leadSource);
            return RedirectToAction("Index");
        }

        // GET: LeadSourcesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeadSourcesController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Deletes(int id)
        {
            _leadSourceLogic.DeteteLeadSource(id);
            return RedirectToAction("Index");
        }

    }
}
