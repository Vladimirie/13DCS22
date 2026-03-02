<?php

namespace App\Http\Controllers\API;

use app\Models\Order;
use App\Http\Controllers\Controller;
use Illuminate\Http\Request;

class OrderController extends Controller
{
    public function index(Request $request) {
        $status = $request->query('status');

        $query = Order::query()
            ->with(['item.menuItem'])
            ->orderByDesc('id');

        if ($status) {
            $query->where('status', $status);
        }

        return response()->json([
            'data' => $query->get()
        ]);
    }

    
}
