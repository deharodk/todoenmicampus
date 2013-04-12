@ModelType IEnumerable(Of libros.Anuncio)
@Imports HtmlAgilityPack

<div class="row"> 
    @For Each item In Model
        Dim currentItem = item
        Dim srcImg As String
        Dim categoria As String
        Dim document As New HtmlAgilityPack.HtmlDocument
        Dim i As Integer = 1
        document.LoadHtml(currentItem.descripcion)

        Dim images = document.DocumentNode.SelectNodes("//img")
        If Not images Is Nothing Then
            For Each image As HtmlNode In images
                srcImg = image.GetAttributeValue("src", "")
                i += 1
                If i > 1 Then Exit For
            Next
        End If
    
        Select Case currentItem.idTipoAnuncio
            Case 1, 2
                categoria = "type-1"
            Case 3, 4
                categoria = "type-3"
            Case 5, 6
                categoria = "type-2"
            Case 7, 8
                categoria = "type-4"
            Case 9, 10
                categoria = "type-5"
            Case Else
                categoria = "type-else"
        End Select
  
        @<div class="span4 marginBottom">
            <div class="box">
                <a href = "/Anuncios/Details/@currentItem.idAnuncio">
                    <div class="img">
                        @If Not srcImg Is Nothing Then
                                @<img src = "@srcImg" alt = "Imagen del anuncio" class = "imgAnuncio"/>
                            Else
                                @<img src = "../../assets/images/no_disponible.gif" class = "imgAnuncio" alt = "No hay imagen para mostrar"/>
                            End If
                    </div>
                    <div class="details">
                        <h2>@currentItem.titulo</h2>
                        <h3><span>Por</span><a target = "_blank" href = "/Usuario/Details/@currentItem.idContacto"> @currentItem.Contacto.nombre</a></h3>
                        <h3><span>El</span> @currentItem.fechaCreacion</h3>
                        <div class="price align-right">$ @Math.Round(currentItem.precioTotal, 2)</div>
                        <div class="footer vab"> 
                            <div class="row-fluid">
                               <a href = '/Anuncios/Categoria/@currentItem.idTipoAnuncio'> <div class="spanCategory type @categoria align-center"><b>@currentItem.TipoAnuncio.nombre</b></div></a>
                            </div>
                        </div>
                    </div>
                 </a>
            </div>
        </div>
        i = 1
        srcImg = Nothing
     Next  
</div>