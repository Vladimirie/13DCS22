<?php

namespace App\Http\Controllers\API;
use App\Models\Test;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class TestController extends Controller
{
    public function index() {
      
            $tests = Test::select('name','age')->get();

            $avgAge = Test::avg('age');
            return response()->json([
            'data' => $tests,
            'avgAge' => $avgAge

        ]);
    }

    public function show($id) {
        $user = Test::select('name', 'age')
        ->where('id', $id)
        ->first();

        if(!$user) {
            return response()->json([
                'message' => "User not found"
            ], 404);
        }
        return response()->json([
            'data' => $user
        ]);

    }
}
