<?php

use App\Http\Controllers\API\TestController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\API\CategoryController;
use App\Http\Controllers\API\MenuItemController;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get('/tests',[TestController::class,'index']);
Route::get('/user/{id}', [TestController::class, 'show']);
Route::post('/category', [CategoryController::class, 'show']);
Route::post('/category/create', [CategoryController::class, 'store']);
Route::put('/category', [CategoryController::class, 'update']);
Route::delete('/category', [CategoryController::class, 'destroy']);
Route::post('/menu/item', [MenuItemController::class,'show']);
Route::put('/menu/item', [MenuItemController::class,'update']);
Route::delete('/menu/item', [MenuItemController::class,'destroy']);