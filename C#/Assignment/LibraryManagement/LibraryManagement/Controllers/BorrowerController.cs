using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.DAL;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BorrowerController : Controller
    {
        //keep track of book change
        private static int OldBookId;
        public bool BookChanged { get; set; }
        private LibraryContext db = new LibraryContext();

        // GET: Borrower
        public ActionResult Index()
        {
            var borrowers = db.Borrowers.Include(b => b.Book);
             
                return View(borrowers.ToList());
            
        }

        // GET: Borrower/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return HttpNotFound();
            }
            return View(borrower);
        }

        // GET: Borrower/Create
        public ActionResult Create()
        {
            // 11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
            // return only those books that are available
            ViewBag.BookId = new SelectList(db.Books.Where(b => b.BookAvailable == true && b.Stock > 0), "BookId", "BookName");
            return View(); 
        }

        // POST: Borrower/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BorrowerId,Occupation,BorrowerName,Phone,BookId,Address")] Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                // get the book which user/borrower wants

                // why needed?????????????????????????????????????????????????????????????????????????????????????
                //BookController bookService = new BookController();

                var book = db.Books.Where(x => x.BookId == borrower.BookId).First();

                // Decrement the Stock by one
                book.Stock--;

                // this check is not required now as the book which is not available will not be visible
                //add only if available
                //if (book != null && book.BookAvailable)
                //{

                    db.Borrowers.Add(borrower);

                // check if stock is available or not, if stock is 0 set availability to false
                    if(book.Stock ==0)
                       book.BookAvailable = false;
                    db.SaveChanges();
                //}


                //find a way to prompt borrower, book is not available
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", borrower.BookId);
            return View(borrower);
        }

        // GET: Borrower/Edit/5

         // ######## FIND WAY TO FIX SAVING OF DATA EVEN IF USER DOESN'T CLICKS ON EDIT BUTTON#######
        public ActionResult Edit(int? id)
        {
            if (id == null)
                
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower borrower = db.Borrowers.Find(id);
            if (borrower == null)
            {
                return HttpNotFound();
            }
          


            // set the OldBookId to the id of book that user is holding 
            OldBookId = borrower.BookId;


            //////// produce only list where book is available
            ViewBag.BookId = new SelectList(db.Books.Where(b => b.BookAvailable == true && b.Stock > 0), "BookId", "BookName", borrower.BookId);
            return View(borrower);
        }

        // POST: Borrower/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BorrowerId,Occupation,BorrowerName,Phone,BookId,Address")] Borrower borrower)
        {
            //get the ID of selected Book
            int CurrentBookId = db.Books.Find(borrower.BookId).BookId;

            // if the ID of book selected is not equal then book has been changed
            if (OldBookId != CurrentBookId)
                BookChanged = true;

            // code for old book
            if (BookChanged)
            {
                db.Books.Find(OldBookId).Stock++;
                db.Books.Find(OldBookId).BookAvailable = true;

            }

            // code for new book
            if (ModelState.IsValid)
            {
                // get the selected book
                var selectedBook = db.Books.Find(CurrentBookId);
                //decrement the stock by one of the book selected
                selectedBook.Stock--;
                if (selectedBook.Stock == 0)
                    selectedBook.BookAvailable = false;

                db.Entry(borrower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", borrower.BookId);
            return View(borrower);
        }

        // GET: Borrower/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower borrower = db.Borrowers.Find(id);

            if (borrower == null)
            {
                return HttpNotFound();
            }
            return View(borrower);
        }

        // POST: Borrower/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Borrower borrower = db.Borrowers.Find(id);
            db.Borrowers.Remove(borrower);
            
            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222

            ///////////////////////////////////////////////////////////////////////////////////////////////////////  


            // get the id of the book that the user is holding or 

            int currentBookId = borrower.BookId;
            // get that book from books database
            var book = db.Books.Find(currentBookId);
            // set it's availability to true i.e available
            book.Stock++;
            book.BookAvailable = true;




            db.SaveChanges();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////




            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
