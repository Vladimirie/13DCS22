<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Order extends Model
{
   protected $fillable = [
        'custumer_name',
        'custumer_phone',
        'status',
        'total'
    ];
       protected $cast  = [
      //  'custumer_name' => 'string',
      //  'custumer_phone' => 'string',
     //   'status' => 'string',
        'total' => 'decimal:2'
    ];

     public function items(): HasMany{
        return $this->hasMany(OrderItem::class);

    }

}
