Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports CasualBoutique

Namespace Controllers
    Public Class SuppliersController
        Inherits System.Web.Mvc.Controller

        Private db As New CasualBoutiqueConnecticutEntities

        ' GET: Suppliers
        Async Function Index() As Task(Of ActionResult)
            Dim suppliers = db.Suppliers.Include(Function(s) s.State)
            Return View(Await suppliers.ToListAsync())
        End Function

        ' GET: Suppliers/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim supplier As Supplier = Await db.Suppliers.FindAsync(id)
            If IsNothing(supplier) Then
                Return HttpNotFound()
            End If
            Return View(supplier)
        End Function

        ' GET: Suppliers/Create
        Function Create() As ActionResult
            ViewBag.StateId = New SelectList(db.States, "StateId", "StateName")
            Return View()
        End Function

        ' POST: Suppliers/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="SupplierId,CompanyName,ContactName,ContactTitle,Address,StateId,Phone")> ByVal supplier As Supplier) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Suppliers.Add(supplier)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.StateId = New SelectList(db.States, "StateId", "StateName", supplier.StateId)
            Return View(supplier)
        End Function

        ' GET: Suppliers/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim supplier As Supplier = Await db.Suppliers.FindAsync(id)
            If IsNothing(supplier) Then
                Return HttpNotFound()
            End If
            ViewBag.StateId = New SelectList(db.States, "StateId", "StateName", supplier.StateId)
            Return View(supplier)
        End Function

        ' POST: Suppliers/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="SupplierId,CompanyName,ContactName,ContactTitle,Address,StateId,Phone")> ByVal supplier As Supplier) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(supplier).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.StateId = New SelectList(db.States, "StateId", "StateName", supplier.StateId)
            Return View(supplier)
        End Function

        ' GET: Suppliers/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim supplier As Supplier = Await db.Suppliers.FindAsync(id)
            If IsNothing(supplier) Then
                Return HttpNotFound()
            End If
            Return View(supplier)
        End Function

        ' POST: Suppliers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim supplier As Supplier = Await db.Suppliers.FindAsync(id)
            db.Suppliers.Remove(supplier)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
