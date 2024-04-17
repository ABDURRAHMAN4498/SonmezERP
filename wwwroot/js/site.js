// // Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// // for details on configuring this project to bundle and minify static web assets.
// function AddItem(btn) {
//   var table = document.getElementById("ExpTable");
//   var rows = table.getElementsByTagName("tr");

//   var lastrowIdx = rows.length - 2;

//   var rowOuterHtml = rows[lastrowIdx].outerHTML;

//   lastrowIdx = lastrowIdx - 1;
//   var nextrowIdx = eval(lastrowIdx) + 1;

//   console.log("Last Row Idx = " + lastrowIdx);
//   console.log("Next Row Idx = " + nextrowIdx);

//   rowOuterHtml = rowOuterHtml.replaceAll(
//     "_" + lastrowIdx + "_",
//     "_" + nextrowIdx + "_"
//   );
//   rowOuterHtml = rowOuterHtml.replaceAll(
//     "[" + lastrowIdx + "]",
//     "[" + nextrowIdx + "]"
//   );
//   rowOuterHtml = rowOuterHtml.replaceAll(
//     "-" + lastrowIdx + "-",
//     "-" + nextrowIdx + "-"
//   );

//   var newRow = table.insertRow();
//   newRow.innerHtml = rowOuterHtml;
// }

// function DeleteItem(btn) {
//   var table = document.getElementById("ExpTable");
//   var rows = table.getElementsByTagName("tr");

//   if (rows.length == 2) {
//     alert("This Row Cannot Be Deleted");
//     return;
//   }
//   var btn = btn.id.replaceAll("btnremove-", "");
//   var idOfIsDeleted = btnIdx + "__IsDeleted";
//   var hidIsDelId = document.querySelector("$[id='" + idOfIsDeleted + "']").id;
//   document.getElementById(hidIsDelId).value = true;
//   $(btn).closest("tr").hide();
//   CalcTotalExperiences();
// }


