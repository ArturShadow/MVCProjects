// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ConfirmarEliminacion(){
    let text = "Esta seguro de eliminarlo?"
        if (!confirm(text)) event.preventDefault()
}