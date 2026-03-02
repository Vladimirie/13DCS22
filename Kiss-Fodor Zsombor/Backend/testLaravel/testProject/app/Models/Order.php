<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasMany;

class Order extends Model
{
    protected $fillable = [
        'customer_name',
        'customer_phone',
        'status',
        'total'
    ];

    protected $cast = [
        'total' => 'decimal:2'
    ];

    public function items():HasMany {
        return $this->hasMany(OrderItem::class);
    }
}
