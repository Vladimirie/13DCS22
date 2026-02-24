<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\HasMany;
use Illuminate\Database\Eloquent\BelongsTo;
class Order_item extends Model
{
       protected $fillable = [
        'order_id',
        'menu_item_id',
        'quantity',
        'unit_price',
        'line_total'
    ];

           protected $cast  = [
       // 'quantity' => 'unsignedinteger',
        'unit_price' => 'decimal:2',
        'line_total' => 'decimal:2'
        
    ];

   public function order(): BelongsTo {
        return $this->belongsTo(Order::class);
   }
     public function menuItem(): BelongsTo {
        return $this->belongsTo(MenuItem::class);
   }

   public function orderItems() : HasMany {
    return $this->hasMany(OrderItem::class);
   }

}
