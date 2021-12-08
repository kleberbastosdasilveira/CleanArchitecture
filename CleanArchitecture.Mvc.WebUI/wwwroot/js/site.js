﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
	$("#msg_box").fadeOut(3500);
});

$("#ImagemUpload").change(function () {
    $("#img_nome").text(this.files[0].name);
    $("#img_nome")[0].style.display = 'block';
});

$("#ImagemUpload").attr("data-val", "true");
$("#ImagemUpload").attr("data-val-required", "Preencha o campo Imagem");


var senha = $('#senha');
var olho = $("#olho");

olho.mousedown(function () {
    senha.attr("type", "text");
});

olho.mouseup(function () {
    senha.attr("type", "password");
});

$("#olho").mouseout(function () {
    $("#senha").attr("type", "password");
});

var senha2 = $('#senha2');
var olho2 = $("#olho2");

olho2.mousedown(function () {
    senha2.attr("type", "text");
});

olho2.mouseup(function () {
    senha2.attr("type", "password");
});

$("#olho2").mouseout(function () {
    $("#senha2").attr("type", "password");
});