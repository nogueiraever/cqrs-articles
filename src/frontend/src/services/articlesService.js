import api from '../infra/api'

class ArticlesServices{
    like(articleId){
        return api.post(`/v1/articles/${articleId}/likes`);
    }

    getLikes(articleId){
        return api.get(`/v1/articles/${articleId}/likes`);
    }
}

export default new ArticlesServices();