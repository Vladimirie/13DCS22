<?php

use App\Http\Controllers\API\CarController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get('/cars', [CarController::class, 'index']);

Route::post('/cars/create', [CarController::class, 'store']);

Route::delete('/cars/delete', [CarController::class, 'destroy']);
