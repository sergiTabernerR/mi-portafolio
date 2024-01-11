package com.example.gestiobus

import android.content.Intent
import android.net.Uri
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageButton
import android.widget.ImageView
import android.widget.TextView
import androidx.core.content.ContextCompat.startActivity
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.example.gestiobus.databinding.CardViewLlocEmblematicBinding


class AdaptadorLlocEmblematic(val llista: List<InteresTuristics>): RecyclerView.Adapter<AdaptadorLlocEmblematic.ViewHolder>() {
    class ViewHolder(vista: View): RecyclerView.ViewHolder(vista) {
        val imatge: ImageView
        val nom: TextView
        val direccio: TextView
        val webImage: ImageButton

        private val binding = CardViewLlocEmblematicBinding.bind(vista)

        init {
            imatge = binding.imageUri
            nom = binding.nomLloc
            direccio = binding.adressa
            webImage = binding.webImage

        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AdaptadorLlocEmblematic.ViewHolder {
        val layout= LayoutInflater.from(parent.context)
        return ViewHolder(layout.inflate(R.layout.card_view_lloc_emblematic, parent, false))
    }

    override fun onBindViewHolder(holder: AdaptadorLlocEmblematic.ViewHolder, position: Int) {
        Glide.with(holder.itemView.context).load(llista[position].urlImg).into(holder.imatge)
        holder.nom.text = llista[position].nom
        holder.direccio.text = llista[position].direccio
        holder.webImage.setOnClickListener {
        val uri = Uri.parse(llista[position].urlWeb)
        val intent = Intent(Intent.ACTION_VIEW, uri)
        holder.itemView.context.startActivity(intent)
        }
    }

    override fun getItemCount(): Int {
        return llista.size
    }
}