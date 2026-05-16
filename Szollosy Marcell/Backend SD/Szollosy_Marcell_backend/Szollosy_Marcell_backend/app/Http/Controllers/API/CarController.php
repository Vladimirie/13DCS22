<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class CarController extends Controller
{
    public function index() {
        $cars = Cars::with('category')->get();
        return response()->json([
            "data" => $cars
        ]);
    }

    public function store(Request $request) {
        $validator = Validator::make($request->all(),[
            'category_id' => 'reuquired|exists:categories,id',
            'name' => 'required|string',
            'description' => 'required|string',
            'color' => 'required|string',
            'avaliable' => 'required|boolean',
            'price' => 'required|integer'
        ]);

        if ($validator->fails()) {
            return response()->json([
                'message' => 'Hiányos adatok'
                ], 400);
        }

        $cars = Car::Create($validator->validated());

        return response()->json([
            'id' => $cars->id
        ], 201);
    }

    public function destroy(Request $request) {
        $cars = Car::find($request->id);
        if (!$cars) {
            return response()->json([
                'message' => 'Ez az autó nemlétezik'
            ], 404);
        }

        $cars->delete();

        return response()->json(null, 204);
    }
}
