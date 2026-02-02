<?php
use App\Http\Controllers\API\TestController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get('/tests',[TestController::class,'index']);

Route::get('/user/{id}', [TestController::class, 'show']);