<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;

class Product extends Model
{
    protected $fillable =
    [
        'category_id',
        'description',
        'ad_date',
        'heavy',
        'price'
    ];
    protected $casts =
    [
        'ad_date' => 'date',
        'heavy' => 'boolean'
    ];
    public function products():BelongsTo
    {
        return $this->belongsTo(Category::class);
    }
}
