@ModelType CasualBoutique.Supplier
@Code
    ViewData("Title") = "Delete supplier"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Supplier</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.Label("Company name", htmlAttributes:=New With {.class = "control-label col-md-2"})
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CompanyName)
        </dd>

        <dt>
            @Html.Label("Contact name", htmlAttributes:=New With {.class = "control-label col-md-2"})
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ContactName)
        </dd>

        <dt>
            @Html.Label("Contact title", htmlAttributes:=New With {.class = "control-label col-md-2"})
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ContactTitle)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.Label("State name", htmlAttributes:=New With {.class = "control-label col-md-2"})
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.State.StateName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Phone)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            @Html.ActionLink("Back", "Index", vbNull, New With {.class = "btn btn-primary"})
            &nbsp;
            <input type="submit" value="Delete" class="btn btn-primary" />
        </div>
    End Using
</div>
