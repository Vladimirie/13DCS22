<?php
use App\Http\Controllers\API\CategoryController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get('/tests',[CategoryController::class,'index']);

Route::get('/user/{id}', [CategoryController::class, 'show']);

Route::post('/category', [CategoryController::class, 'show']);

Route::post('/category/create', [CategoryController::class, 'show']);