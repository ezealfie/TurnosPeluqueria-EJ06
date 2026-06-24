// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CambiarFecha(id){
document.getElementById('atender_'+id).style.display = 'none';
document.getElementById('cancelar_'+id).style.display = 'none';
document.getElementById('editar_'+id).style.display = 'none';
document.getElementById('fecha_'+id).style.display = 'inline';




}
function VolverAInicio(id){
    document.getElementById('atender'+id).style.display = 'inline';
document.getElementById('cancelar_'+id).style.display = 'inline';
document.getElementById('editar_'+id).style.display = 'inline';
document.getElementById('fecha_'+id).style.display = 'none';
}