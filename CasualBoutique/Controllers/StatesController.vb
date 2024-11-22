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
    Public Class StatesController
        Inherits System.Web.Mvc.Controller

        Private db As New CasualBoutiqueConnecticutEntities

        ' GET: States
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.States.ToListAsync())
        End Function

        ' GET: States/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim state As State = Await db.States.FindAsync(id)
            If IsNothing(state) Then
                Return HttpNotFound()
            End If
            Return View(state)
        End Function

        ' GET: States/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: States/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="StateId,StateName")> ByVal state As State) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.States.Add(state)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(state)
        End Function

        ' GET: States/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim state As State = Await db.States.FindAsync(id)
            If IsNothing(state) Then
                Return HttpNotFound()
            End If
            Return View(state)
        End Function

        ' POST: States/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="StateId,StateName")> ByVal state As State) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(state).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(state)
        End Function

        ' GET: States/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim state As State = Await db.States.FindAsync(id)
            If IsNothing(state) Then
                Return HttpNotFound()
            End If
            Return View(state)
        End Function

        ' POST: States/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim state As State = Await db.States.FindAsync(id)
            db.States.Remove(state)
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
