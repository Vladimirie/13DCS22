<?php

use App\Http\Controllers\API\CategoryController;
use App\Http\Controllers\API\BookController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::post('/category', [CategoryController::class, 'show']);
Route::post('/category/create', [CategoryController::class, 'store']);
Route::put('/category', [CategoryController::class, 'update']);
Route::delete('/category', [CategoryController::class, 'destroy']);

Route::post('/book', [BookController::class, 'show']);
Route::post('/book/create', [BookController::class, 'store']);
Route::put('/book', [BookController::class, 'update']);
Route::delete('/book', [BookController::class, 'destroy']);