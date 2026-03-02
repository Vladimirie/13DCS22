<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\MenuItam;
class MenuItemController extends Controller
{
    //
    public function show(Request $request) {
        $validated = $request->validate([
            'id' => ['required', 'integer' , 'exists:menu_items,id']
        ]);
        $item = MenuItam::with('category')->findOrFail($validated['id']);
        return response()->json([
            'data' => $item
        ]);
    }

    /*public function update(Request $request){
        $validated = $request->validate([
            'id' => ['required', 'integer', 'exists:menu_items,id']
        ])
    }*/





}