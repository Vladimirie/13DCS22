<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Title;
use App\Models\Category;

class TitleController extends Controller
{
    // lista // szűrés // kategória
    public function index(Request $request)
    {
        $query = Title::with('category');

        if ($request->author) {
            $query->where('author', 'like', '%' . $request->author . '%');
        }

        return $query->get();
    }

    // egy elem
    public function show($id)
    {
        return Title::with('category')->findOrFail($id);
    }

    // létrehozás
    public function store(Request $request)
    {
        $validated = $request->validate([
            'title' => 'required',
            'author' => 'required',
            'published_year' => 'required|integer|min:1000|max:' . date('Y'),
            'pages' => 'required|integer|min:1',
            'category_id' => 'required|exists:categories,id'
        ]);

        return Title::create($validated);
    }

    // módosítás
    public function update(Request $request, $id)
    {
        $title = Title::findOrFail($id);

        $validated = $request->validate([
            'title' => 'required',
            'author' => 'required',
            'published_year' => 'required|integer|min:1000|max:' . date('Y'),
            'pages' => 'required|integer|min:1',
            'category_id' => 'required|exists:categories,id'
        ]);

        $title->update($validated);

        return $title;
    }

    // törlés
    public function destroy($id)
    {
        Title::destroy($id);
        return response()->json(['message' => 'Deleted']);
    }

    // 8. feladat
    public function titlesByCategory($id)
    {
        return Title::where('category_id', $id)->with('category')->get();
    }
}