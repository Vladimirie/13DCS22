<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get("/furniture",ApiProductController:: class .'index');
Route::post('/furniture/create', ApiProductController::class .'');
