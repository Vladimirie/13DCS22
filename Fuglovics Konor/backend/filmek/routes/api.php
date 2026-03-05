<?php

use App\Http\Controllers\API\CategoryController;
use App\Http\Controllers\API\FilmController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::post('/category', [CategoryController::class, 'show']);
Route::post('/category/create', [CategoryController::class, 'store']);
Route::put('/category', [CategoryController::class, 'update']);
Route::delete('/category', [CategoryController::class, 'destroy']);

Route::post('/film', [FilmController::class, 'show']);
Route::post('/film/create', [FilmController::class, 'store']);
Route::put('/film', [FilmController::class, 'update']);
Route::delete('/film', [FilmController::class, 'destroy']);
