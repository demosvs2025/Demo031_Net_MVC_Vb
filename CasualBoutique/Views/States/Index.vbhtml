@ModelType IEnumerable(Of CasualBoutique.State)
@Code
    ViewData("Title") = "States"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>States</h2>

<p>
    @Html.ActionLink("New", "Create", vbNull, New With {.class = "btn btn-primary"})
</p>
<table class="table">
    <tr>
        <th>
            @Html.Label("State name")
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StateName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.StateId}, New With {.class = "btn btn-primary"}) 
            &nbsp;
            @Html.ActionLink("Delete", "Delete", New With {.id = item.StateId}, New With {.class = "btn btn-primary"})
        </td>
    </tr>
Next

</table>
