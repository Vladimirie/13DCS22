<?php

namespace App\Http\Controllers\API;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use App\Models\MenuItem;
class MenuItemController extends Controller
{
    //
    public function show(Request $request) {
        $validated = $request->validate([
            'id' => ['required', 'integer' , 'exists:menu_items,id']
        ]);
        $item = MenuItem::with('category')->findOrFail($validated['id']);
        return response()->json([
            'data' => $item
        ]);
    }





}
