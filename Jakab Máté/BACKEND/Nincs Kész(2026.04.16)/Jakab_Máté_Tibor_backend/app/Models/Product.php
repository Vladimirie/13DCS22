<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Product extends Model
{
    protected $fillable = [
        'cate_id',
        'description',
        'ad_date',
        'heavy',
        'price'
    ] ;
    protected $casts = [
        'ad_date'=>'date',
        'heavy'=>'boolean'
    ] ;
    public function category():BelongsTo
    {
        return $this->belongsTo(Category::class,'category_id');
    }
}
