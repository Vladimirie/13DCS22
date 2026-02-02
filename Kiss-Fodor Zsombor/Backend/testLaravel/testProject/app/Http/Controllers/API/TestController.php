<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use App\Models\Test;
use Illuminate\Http\Request;

use function Laravel\Prompts\text;

class TestController extends Controller
{
    public function Index() {

        $tests = Test::select('name', 'age')-> get();

        $avgAge = Test::avg('age');

        return response()->json([
            'data' => $tests,
            'avgAge' => $avgAge
        ]);
    }

    public function show($id) {
        $user = Test::select('name', 'age')
        -> where('id' == $id)
        ->first();

        if (!$user) {
            return response()->json([
                'message' => 'user not found'
            ], 418);
        }

        return response()->json([
            'data' => $user
        ]);
    }
}
