@ModelType IEnumerable(Of CasualBoutique.Supplier)
@Code
    ViewData("Title") = "Suppliers"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Suppliers</h2>

<p>
    @Html.ActionLink("New", "Create", vbNull, New With {.class = "btn btn-primary"})
</p>
<table class="table">
    <tr>
        <th>
            @Html.Label("Company name")
        </th>
        <th>
            @Html.Label("Contact name")
        </th>
        <th>
            @Html.Label("Contact title")
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Address)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </th>
        <th>
            @Html.Label("State name")
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CompanyName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ContactName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ContactTitle)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Address)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Phone)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.State.StateName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.SupplierId}, New With {.class = "btn btn-primary"})
            &nbsp;
            @Html.ActionLink("Delete", "Delete", New With {.id = item.SupplierId}, New With {.class = "btn btn-primary"})
        </td>
    </tr>
Next

</table>
